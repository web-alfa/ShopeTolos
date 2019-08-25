let divPriceeEl = document.createElement("div");
let divPriceedataEl = document.createElement("div");
let sapanPr = document.createElement("span");

let divSaleEl = document.createElement("div");
let divSaledataEl = document.createElement("div");
let sapanSl = document.createElement("span");

function CreatePricceEll() {
    let divHead = document.createElement("div");

    divPriceedataEl.style.height = "300px";
    divPriceedataEl.style.padding = "5px";

    let hr = document.createElement("hr");
    hr.style.margin = "5px";

    let span = document.createElement("span");
    span.style.fontSize = "20px";
    span.textContent = "Price dynamics";
    divHead.style.height = "60px";
    divHead.style.padding = "20px";
    divHead.appendChild(span);

    divPriceeEl.style.position = "fixed";
    divPriceeEl.style.backgroundColor = "white";
    divPriceeEl.style.webkitBoxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divPriceeEl.style.boxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divPriceeEl.style.left = "10px";
    divPriceeEl.style.bottom = "74px";
    divPriceeEl.style.borderRadius = "5px";
    divPriceeEl.style.height = "400px";
    divPriceeEl.style.width = "300px";
    divPriceeEl.style.display = "none";
    divPriceeEl.style.zIndex = 102;
    divPriceeEl.appendChild(divHead);
    divPriceeEl.appendChild(hr);
    divPriceeEl.appendChild(divPriceedataEl);
    document.body.append(divPriceeEl);
}

function CreateSalleEll() {
    let divHead = document.createElement("div");

    let spanNotData = document.createElement("span");
    spanNotData.textContent = "No data yet for this product, soon this data will appear";
    divSaledataEl.style.height = "420px";
    divSaledataEl.style.padding = "10px";

    let hr = document.createElement("hr");
    hr.style.margin = "5px";

    let span = document.createElement("span");
    span.style.fontSize = "20px";
    span.textContent = "Seller Rating";
    divHead.style.height = "60px";
    divHead.style.padding = "20px";
    divHead.appendChild(span);

    divSaleEl.style.position = "fixed";
    divSaleEl.style.backgroundColor = "white";
    divSaleEl.style.webkitBoxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divSaleEl.style.boxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divSaleEl.style.left = "10px";
    divSaleEl.style.bottom = "74px";
    divSaleEl.style.borderRadius = "5px";
    divSaleEl.style.height = "500px";
    divSaleEl.style.width = "470px";
    divSaleEl.style.display = "none";
    divSaleEl.style.zIndex = 102;
    divSaleEl.appendChild(divHead);
    divSaleEl.appendChild(hr);
    divSaleEl.appendChild(divSaledataEl);
    document.body.append(divSaleEl);
}

function ready() {
    CreatePricceEll();
    CreateSalleEll();
    let divEl = document.createElement("div");
    let divLogo = document.createElement("div");
    let divPrice = document.createElement("div");
    let divSalle = document.createElement("div");

    //let img1 = document.createElement("img");
    let span = document.createElement("span");
    span.textContent = "A";
    span.style.color = "white";
    span.style.fontSize = "40px";
    span.style.margin = "9px";
    //img1.src = chrome.extension.getURL('Icon/logo.png');
    divLogo.style.marginBottom = "5px";
    divLogo.style.marginLeft = "5px";
    divLogo.style.width = "50px";
    divLogo.style.height = "50px";
    divLogo.style.borderBottomLeftRadius = "5px";
    divLogo.style.borderBottomRightRadius = "5px";
    divLogo.appendChild(span);

    let sapanText = document.createElement("span");
    let divPr = document.createElement("div");
    sapanPr.textContent = "--$";
    sapanPr.style.margin = "9px";
    sapanPr.style.fontSize = "20px";
    sapanText.textContent = "Pricce";
    sapanText.style.margin = "5px";
    sapanText.style.fontSize = "15px";
    divPr.style.height = "25px";
    divPr.appendChild(sapanPr);
    divPrice.style.marginBottom = "5px";
    divPrice.style.width = "50px";
    divPrice.style.height = "50px";
    divPrice.style.borderBottomLeftRadius = "5px";
    divPrice.style.borderBottomRightRadius = "5px";
    divPrice.addEventListener('click', ShowPrrice);
    divPrice.appendChild(divPr);
    divPrice.appendChild(sapanText);

    let sapanText1 = document.createElement("span");
    let divSl = document.createElement("div");
    sapanSl.textContent = "--";
    sapanSl.style.margin = "9px";
    sapanSl.style.fontSize = "20px";
    sapanText1.textContent = "Raiting";
    sapanText1.style.margin = "5px";
    sapanText1.style.fontSize = "15px";
    divSl.style.height = "25px";
    divSl.appendChild(sapanSl);
    divSalle.style.marginBottom = "5px";
    divSalle.style.marginRight = "5px";
    divSalle.style.width = "60px";
    divSalle.style.height = "55px";
    divSalle.style.borderBottomLeftRadius = "5px";
    divSalle.style.borderBottomRightRadius = "5px";
    divSalle.addEventListener('click', ShowSalle);
    divSalle.appendChild(divSl);
    divSalle.appendChild(sapanText1);

    divEl.style.position = "fixed";
    divEl.style.backgroundColor = "#ff4747";
    divEl.style.color = "white";
    divEl.style.left = "10px";
    divEl.style.bottom = "15px";
    divEl.style.borderRadius = "5px";
    divEl.style.display = "flex";
    divEl.style.zIndex = 101;
    divEl.appendChild(divLogo);
    divEl.appendChild(divPrice);
    divEl.appendChild(divSalle);
    document.body.append(divEl);
}

document.addEventListener("DOMContentLoaded", ready);

function initAli() {
    if (sessionStorage.getItem("isLoadPage") !== "true") {
        if (!location.href.includes("ITEM_DETAIL")) {
            sessionStorage.setItem("isLoadPage", "true");
            window.location.href = "https://buyeasy.by/redirect/cpa/o/psw5xl287q2fpfkyc2osnef1t2dqopqh/?to=" + location.href;
        }
    }
    window.onbeforeunload = function () {
        sessionStorage.removeItem("isLoadPage");
    };
    let idShiping = GetIdShoping();
    GetResponseStatistic(idShiping);
}

function GetIdShoping() {
    let urlCurentPage = location.href;  
    return urlCurentPage.substring(urlCurentPage.indexOf("/item/") + 6, urlCurentPage.indexOf(".html"));
}

function GetResponseStatistic(idShip) {
    let body = "idShiping=" + idShip;
    let xhr = new XMLHttpRequest();
    xhr.open('POST', 'https://185.204.0.238/Statistics', true);
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.setRequestHeader('Access-Control-Allow-Credentials', true);
    xhr.send(body);
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4) {
            return;
        }
        if (xhr.status === 200) {
            let response = JSON.parse(xhr.responseText);
            let responseOrder = response.ResponseOrder;
            let responseStore = response.ResponseStore;
            SetChildrenRaitingSalle(responseStore);
            SetChildrenPrice(responseOrder);
        }
        else {
            let spanNotData = document.createElement("span");
            spanNotData.textContent = "No data yet for this product, soon this data will appear";
            divPriceedataEl.appendChild(spanNotData);
            divSaledataEl.appendChild(spanNotData);
        }
    }
}

function SetChildrenRaitingSalle(responseStore) {
    if (responseStore.Status === "OK") {
        let pRaitings = document.createElement("span");
        let divRaitings = document.createElement("div");

        let spanCommunication = document.createElement("span");
        let divDotCommunication = document.createElement("div");
        let divParentCommunication = document.createElement("div");
        divParentCommunication.style.display = "flex";
        divDotCommunication.style.background = GetColorResultStatistick(responseStore.CommunicationS);
        divDotCommunication.style.height = "12px";
        divDotCommunication.style.width = "12px";
        divDotCommunication.style.borderRadius = "10px";
        divDotCommunication.style.webkitBorderRadius = "10px";
        divDotCommunication.style.mozBorderRadius = "10px";
        divDotCommunication.style.margin = "7px";
        divDotCommunication.style.minWidth = "12px";
        spanCommunication.textContent = responseStore.Communication;
        spanCommunication.style.fontSize = "19px";
        divParentCommunication.style.marginTop = "10px";
        divParentCommunication.appendChild(divDotCommunication);
        divParentCommunication.appendChild(spanCommunication);
        divRaitings.append(divParentCommunication);

        let spanShippingSpeed = document.createElement("span");
        let divDotShippingSpeed = document.createElement("div");
        let divParentShippingSpeed = document.createElement("div");
        divParentShippingSpeed.style.display = "flex";
        divDotShippingSpeed.style.background = GetColorResultStatistick(responseStore.ShippingSpeedS);
        divDotShippingSpeed.style.height = "12px";
        divDotShippingSpeed.style.width = "12px";
        divDotShippingSpeed.style.borderRadius = "10px";
        divDotShippingSpeed.style.webkitBorderRadius = "10px";
        divDotShippingSpeed.style.mozBorderRadius = "10px";
        divDotShippingSpeed.style.margin = "7px";
        divDotShippingSpeed.style.minWidth = "12px";
        spanShippingSpeed.textContent = responseStore.ShippingSpeed;
        spanShippingSpeed.style.fontSize = "19px";
        divParentShippingSpeed.style.marginTop = "10px";
        divParentShippingSpeed.appendChild(divDotShippingSpeed);
        divParentShippingSpeed.appendChild(spanShippingSpeed);
        divRaitings.append(divParentShippingSpeed);

        let spanItemAsDescribed = document.createElement("span");
        let divDotItemAsDescribed = document.createElement("div");
        let divParentItemAsDescribed = document.createElement("div");
        divParentItemAsDescribed.style.display = "flex";
        divDotItemAsDescribed.style.background = GetColorResultStatistick(responseStore.ItemAsDescribedS);
        divDotItemAsDescribed.style.height = "12px";
        divDotItemAsDescribed.style.width = "12px";
        divDotItemAsDescribed.style.borderRadius = "10px";
        divDotItemAsDescribed.style.webkitBorderRadius = "10px";
        divDotItemAsDescribed.style.mozBorderRadius = "10px";
        divDotItemAsDescribed.style.margin = "7px";
        divDotItemAsDescribed.style.minWidth = "12px";
        spanItemAsDescribed.textContent = responseStore.ItemAsDescribed;
        spanItemAsDescribed.style.fontSize = "19px";
        divParentItemAsDescribed.style.marginTop = "10px";
        divParentItemAsDescribed.appendChild(divDotItemAsDescribed);
        divParentItemAsDescribed.appendChild(spanItemAsDescribed);
        divRaitings.append(divParentItemAsDescribed);

        let spanStartOfSale = document.createElement("span");
        let divDotStartOfSale = document.createElement("div");
        let divParentStartOfSale = document.createElement("div");
        divParentStartOfSale.style.display = "flex";
        divDotStartOfSale.style.background = GetColorResultStatistick(responseStore.StartOfSaleS);
        divDotStartOfSale.style.height = "12px";
        divDotStartOfSale.style.width = "12px";
        divDotStartOfSale.style.borderRadius = "10px";
        divDotStartOfSale.style.webkitBorderRadius = "10px";
        divDotStartOfSale.style.mozBorderRadius = "10px";
        divDotStartOfSale.style.margin = "7px";
        divDotStartOfSale.style.minWidth = "12px";
        spanStartOfSale.textContent = responseStore.StartOfSale;
        spanStartOfSale.style.fontSize = "19px";
        divParentStartOfSale.style.marginTop = "10px";
        divParentStartOfSale.appendChild(divDotStartOfSale);
        divParentStartOfSale.appendChild(spanStartOfSale);
        divRaitings.append(divParentStartOfSale);

        let spanFeedBack = document.createElement("span");
        let divDotFeedBack = document.createElement("div");
        let divParentFeedBack = document.createElement("div");
        divParentFeedBack.style.display = "flex";
        divDotFeedBack.style.background = GetColorResultStatistick(responseStore.FeedBackS);
        divDotFeedBack.style.height = "12px";
        divDotFeedBack.style.width = "12px";
        divDotFeedBack.style.borderRadius = "10px";
        divDotFeedBack.style.webkitBorderRadius = "10px";
        divDotFeedBack.style.mozBorderRadius = "10px";
        divDotFeedBack.style.margin = "7px";
        divDotFeedBack.style.minWidth = "12px";
        spanFeedBack.textContent = responseStore.FeedBack;
        spanFeedBack.style.fontSize = "19px";
        divParentFeedBack.style.marginTop = "10px";
        divParentFeedBack.appendChild(divDotFeedBack);
        divParentFeedBack.appendChild(spanFeedBack);
        divRaitings.append(divParentFeedBack);

        divRaitings.style.padding = "10px";
        pRaitings.style.color = GetColorResultStatistick(responseStore.Seller_RatingS);
        //pRaitings.style.color = GetColorResultStatistick(90);
        pRaitings.style.marginLeft = "10px";
        pRaitings.textContent = responseStore.Seller_Rating + ", " + responseStore.Seller_RatingS + "%";
        //pRaitings.textContent = ":)  Высоко, 90%";
        pRaitings.style.fontSize = "28px";
        divSaledataEl.appendChild(pRaitings);
        divSaledataEl.appendChild(divRaitings);
    }
    else {
        let spanNotData = document.createElement("span");
        spanNotData.textContent = "No data yet for this product, soon this data will appear";
        divSaledataEl.appendChild(spanNotData);
    }
}

function SetChildrenPrice(responseOrder) {
    if (responseOrder.Status === "OK") {
        //
    }
    else {
        let spanNotData = document.createElement("span");
        spanNotData.textContent = "No data yet for this product, soon this data will appear";
        divPriceedataEl.appendChild(spanNotData);
    }
}

function ShowPrrice(elmClick) {
    let elm = elmClick.currentTarget;
    if (divPriceeEl.style.display === "none") {
        elm.style.color = "#ff4747";
        elm.style.backgroundColor = "white";
        divPriceeEl.style.display = "block";
    }
    else {
        elm.style.color = "white";
        elm.style.backgroundColor = "#ff4747";
        divPriceeEl.style.display = "none";
    }
}

function ShowSalle(elmClick) {
    let elm = elmClick.currentTarget;
    if (divSaleEl.style.display === "none") {
        elm.style.color = "#ff4747";
        elm.style.backgroundColor = "white";
        divSaleEl.style.display = "block";
    }
    else {
        elm.style.color = "white";
        elm.style.backgroundColor = "#ff4747";
        divSaleEl.style.display = "none";
    }
}

function GetColorResultStatistick(raitings) {
    let color;
    if (raitings < 33) {
        color = "#ff4747";
    }
    else if (raitings >= 33 && 66 >= raitings) {
        color = "#D9A71F";
    }
    else if (66 < raitings) {
        color = "#04B45F";
    }
    return color;
}