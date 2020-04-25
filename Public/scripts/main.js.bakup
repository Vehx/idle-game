"use strict";

const money = document.querySelector(".game__info-money-value");
const income = document.querySelector(".game__info-income-value");
const farmsOwned = document.querySelector(".farms__owned-value");
const farmsCost = document.querySelector(".farms__cost-value");
const farmBuyBtn = document.querySelector(".farms__buy-btn");

let moneyRealValue = 0;
let incomeRealValue = 0;
let farmsRealValue = 0;
let farmRealCost = 100;
const farmIncomeIncrease = 1;
const gameDifficultyMultiplier = 1.1;
const startMoney = 100;

const gameLoop = () => {
    // console.log("Real money: " + moneyRealValue);
    // console.log("Farm current cost: " + farmRealCost);
    updateMoney((moneyRealValue += incomeRealValue));
    if (moneyRealValue >= farmRealCost) {
        setFarmBuyBtnActive();
    } else {
        setFarmBuyBtnDisabled();
    }
    setTimeout(() => {
        gameLoop();
    }, 1000);
};

// functions to update value used in js and value shown in dom
const updateMoney = value => {
    moneyRealValue = value;
    money.textContent = value;
};

const updateIncome = value => {
    incomeRealValue = value;
    income.textContent = value;
};

const updateFarms = (farmCount, farmCost) => {
    farmsRealValue = farmCount;
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
    updateMoney(Math.round((moneyRealValue -= farmRealCost)));
    updateIncome(Math.round((incomeRealValue += farmIncomeIncrease)));
    farmRealCost = Math.round(farmRealCost * gameDifficultyMultiplier);
    updateFarms((farmsRealValue += 1), farmRealCost);
};

const gameStart = () => {
    if (isFirstTime) {
        updateMoney(startMoney);
    }

    // console.log(moneyRealValue);
    // console.log(incomeRealValue);
    // console.log(farmsRealValue);

    gameLoop();
};

const isFirstTime = true;

gameStart();
