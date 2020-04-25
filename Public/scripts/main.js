"use strict";

const money = document.querySelector(".game__info-money-value");
const income = document.querySelector(".game__info-income-value");
const farmsOwned = document.querySelector(".farms__owned-value");
const farmsCost = document.querySelector(".farms__cost-value");
const farmBuyBtn = document.querySelector(".farms__buy-btn");

const gameUrl = "http://localhost:5000/player/0";

let moneyValue = 0;
let incomeValue = 0;
let farmsValue = 0;
let farmCost = 100;
let farmIncomeIncrease = 1;
let farmCostIncreaseMultiplier = 1.0;
let gameDifficultyMultiplier = 1.0;

const gameLoop = () => {
    setInterval(() => {
        console.log("Current money: " + moneyValue);
        console.log("Current income: " + incomeValue);
        console.log("Farms currently owned: " + farmsValue);
        console.log("Farm current cost: " + farmCost);
        updateMoney((moneyValue += incomeValue));
        if (moneyValue >= farmCost) {
            setFarmBuyBtnActive();
        } else {
            setFarmBuyBtnDisabled();
        }
        updateGame();
    }, 1000);

    // setTimeout(() => {
    //     gameLoop();
    // }, 1000);
};

const updateGame = () => {
    fetch(gameUrl)
        .then((r) => r.json())
        .then((r) => {
            console.log(r);
            moneyValue = r.data.money;
            incomeValue = r.data.income;
            farmCost = r.data.buildings[0].cost;
            farmIncomeIncrease = r.data.buildings[0].incomeIncrease;
        });
};

// functions to update value used in js and value shown in dom
const updateMoney = (value) => {
    moneyValue = value;
    money.textContent = value;
};

const updateIncome = (value) => {
    incomeValue = value;
    income.textContent = value;
};

const updateFarms = (farmCount, farmCost) => {
    farmsValue = farmCount;
    farmsOwned.textContent = farmCount;
    farmsCost.textContent = farmCost;
};

const setFarmBuyBtnActive = () => {
    if (!farmBuyBtn.classList.contains("active-buy-btn")) {
        farmBuyBtn.classList.add("active-buy-btn");
        farmBuyBtn.classList.remove("disabled-buy-btn");
        farmBuyBtn.addEventListener("click", buyFarm);
    }
};

const setFarmBuyBtnDisabled = () => {
    if (!farmBuyBtn.classList.contains("disabled-buy-btn")) {
        farmBuyBtn.classList.remove("active-buy-btn");
        farmBuyBtn.classList.add("disabled-buy-btn");
        farmBuyBtn.removeEventListener("click", buyFarm);
    }
};

const buyFarm = () => {
    setFarmBuyBtnDisabled();
    updateMoney(Math.round((moneyValue -= farmCost)));
    updateIncome(Math.round((incomeValue += farmIncomeIncrease)));
    farmCost = Math.round(farmCost * gameDifficultyMultiplier);
    updateFarms((farmsValue += 1), farmCost);
};

const gameStart = () => {
    // if (isFirstTime) {
    //     updateMoney(startMoney);
    // }

    // console.log(moneyValue);
    // console.log(incomeValue);
    // console.log(farmsValue);

    gameLoop();
};

// const isFirstTime = true;

gameStart();
