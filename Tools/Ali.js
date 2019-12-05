let divPriceeEl = document.createElement("div");
let divPriceedataEl = document.createElement("div");
let sapanPr = document.createElement("span");
let divPrice = document.createElement("div");

let divSaleEl = document.createElement("div");
let divSaledataEl = document.createElement("div");
let sapanSl = document.createElement("span");
let divSalle = document.createElement("div");

function CreatePricceEll() {
    let divHead = document.createElement("div");

    divPriceedataEl.style.height = "300px";
    divPriceedataEl.style.padding = "5px";

    let hr = document.createElement("hr");
    hr.style.margin = "5px";

    let span = document.createElement("span");
    span.style.fontSize = "17pt";
    span.style.fontFamily = "Open Sans";
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
    divSaledataEl.style.padding = "10px";

    let hr = document.createElement("hr");
    hr.style.margin = "5px";

    let span = document.createElement("span");
    span.style.fontSize = "17pt";
    span.style.fontFamily = "Open Sans";
    span.textContent = "Seller Rating";
    divHead.style.height = "60px";
    divHead.style.padding = "20px";
    divHead.appendChild(span);

    divSaleEl.style.position = "fixed";
    divSaleEl.style.backgroundColor = "white";
    divSaleEl.style.webkitBoxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divSaleEl.style.boxShadow = "1px 2px 14px 3px rgba(0,0,0,0.31)";
    divSaleEl.style.left = "10px";
    divSaleEl.style.bottom = "64px";
    divSaleEl.style.borderRadius = "5px";
    divSaleEl.style.height = "400px";
    divSaleEl.style.width = "342px";
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

    let img1 = document.createElement("img");
    let span = document.createElement("span");
    span.textContent = "A";
    span.style.color = "white";
    span.style.fontSize = "40px";
    span.style.margin = "9px"; 
    img1.style.margin = "9px";
    img1.src = "https://185.204.0.238/Image?name=logo.png"; //chrome.extension.getURL('Icon/logo.png');
    divLogo.style.marginBottom = "4px";
    divLogo.style.marginLeft = "4px";
    divLogo.style.width = "50px";
    divLogo.style.height = "44px";
    divLogo.style.borderBottomLeftRadius = "3px";
    divLogo.style.borderBottomRightRadius = "3px";
    divLogo.appendChild(img1);

    let sapanText = document.createElement("span");
    let divPr = document.createElement("div");
    sapanPr.textContent = "$";
    sapanPr.style.fontSize = "18pt";
    sapanPr.style.fontFamily = "Open Sans";
    sapanText.textContent = "Pricce";
    sapanText.style.textAlign = "centr";
    sapanText.style.fontFamily = "Open Sans";
    sapanText.style.fontSize = "12pt";
    divPr.style.height = "25px";
    divPr.appendChild(sapanPr);
    divPrice.style.marginBottom = "4px";
    divPrice.style.paddingLeft = "10px";
    divPrice.style.paddingRight = "10px";
    divPrice.style.display = "flex";
    divPrice.style.alignItems = "center";
    divPrice.style.justifyContent = "center";
    divPrice.style.minWidth = "40px";
    divPrice.style.maxWidth = "200px";
    divPrice.style.flexDirection = "column";
    divPrice.style.height = "44px";
    divPrice.style.borderBottomLeftRadius = "3px";
    divPrice.style.borderBottomRightRadius = "3px";
    divPrice.addEventListener('click', ShowPrrice);
    divPrice.appendChild(divPr);
    divPrice.appendChild(sapanText);

    let sapanText1 = document.createElement("span");
    let divSl = document.createElement("div");
    sapanSl.textContent = "%";
    sapanSl.style.fontSize = "18pt";
    sapanSl.style.fontFamily = "Open Sans";
    sapanText1.textContent = "Salle";
    sapanText1.style.fontFamily = "Open Sans";
    sapanText1.style.fontSize = "12pt";
    divSl.style.height = "25px";
    divSl.appendChild(sapanSl);
    divSalle.style.marginBottom = "4px";
    divSalle.style.paddingLeft = "10px";
    divSalle.style.paddingRight = "10px";
    divSalle.style.marginRight = "4px";
    divSalle.style.display = "flex";
    divSalle.style.alignItems = "center";
    divSalle.style.justifyContent = "center";
    divSalle.style.minWidth = "40px";
    divSalle.style.maxWidth = "200px";
    divSalle.style.height = "44px";
    divSalle.style.flexDirection = "column";
    divSalle.style.borderBottomLeftRadius = "3px";
    divSalle.style.borderBottomRightRadius = "3px";
    divSalle.addEventListener('click', ShowSalle);
    divSalle.appendChild(divSl);
    divSalle.appendChild(sapanText1);

    divEl.style.position = "fixed";
    divEl.style.backgroundColor = "#fa3c44";
    divEl.style.color = "white";
    divEl.style.left = "10px";
    divEl.style.bottom = "15px";
    divEl.style.borderRadius = "3px";
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
        divDotCommunication.style.height = "8px";
        divDotCommunication.style.width = "8px";
        divDotCommunication.style.borderRadius = "10px";
        divDotCommunication.style.webkitBorderRadius = "10px";
        divDotCommunication.style.mozBorderRadius = "10px";
        divDotCommunication.style.margin = "7px";
        divDotCommunication.style.minWidth = "8px";
        spanCommunication.textContent = responseStore.Communication;
        spanCommunication.style.fontSize = "12pt";
        spanCommunication.style.fontFamily = "Myriad Pro";
        divParentCommunication.style.marginTop = "5px";
        divParentCommunication.appendChild(divDotCommunication);
        divParentCommunication.appendChild(spanCommunication);
        divRaitings.append(divParentCommunication);

        let spanShippingSpeed = document.createElement("span");
        let divDotShippingSpeed = document.createElement("div");
        let divParentShippingSpeed = document.createElement("div");
        divParentShippingSpeed.style.display = "flex";
        divDotShippingSpeed.style.background = GetColorResultStatistick(responseStore.ShippingSpeedS);
        divDotShippingSpeed.style.height = "8px";
        divDotShippingSpeed.style.width = "8px";
        divDotShippingSpeed.style.borderRadius = "10px";
        divDotShippingSpeed.style.webkitBorderRadius = "10px";
        divDotShippingSpeed.style.mozBorderRadius = "10px";
        divDotShippingSpeed.style.margin = "7px";
        divDotShippingSpeed.style.minWidth = "8px";
        spanShippingSpeed.textContent = responseStore.ShippingSpeed;
        spanShippingSpeed.style.fontSize = "12pt";
        spanShippingSpeed.style.fontFamily = "Myriad Pro";
        divParentShippingSpeed.style.marginTop = "5px";
        divParentShippingSpeed.appendChild(divDotShippingSpeed);
        divParentShippingSpeed.appendChild(spanShippingSpeed);
        divRaitings.append(divParentShippingSpeed);

        let spanItemAsDescribed = document.createElement("span");
        let divDotItemAsDescribed = document.createElement("div");
        let divParentItemAsDescribed = document.createElement("div");
        divParentItemAsDescribed.style.display = "flex";
        divDotItemAsDescribed.style.background = GetColorResultStatistick(responseStore.ItemAsDescribedS);
        divDotItemAsDescribed.style.height = "8px";
        divDotItemAsDescribed.style.width = "8px";
        divDotItemAsDescribed.style.borderRadius = "10px";
        divDotItemAsDescribed.style.webkitBorderRadius = "10px";
        divDotItemAsDescribed.style.mozBorderRadius = "10px";
        divDotItemAsDescribed.style.margin = "7px";
        divDotItemAsDescribed.style.minWidth = "8px";
        spanItemAsDescribed.textContent = responseStore.ItemAsDescribed;
        spanItemAsDescribed.style.fontSize = "12pt";
        spanItemAsDescribed.style.fontFamily = "Myriad Pro";
        divParentItemAsDescribed.style.marginTop = "5px";
        divParentItemAsDescribed.appendChild(divDotItemAsDescribed);
        divParentItemAsDescribed.appendChild(spanItemAsDescribed);
        divRaitings.append(divParentItemAsDescribed);

        let spanStartOfSale = document.createElement("span");
        let divDotStartOfSale = document.createElement("div");
        let divParentStartOfSale = document.createElement("div");
        divParentStartOfSale.style.display = "flex";
        divDotStartOfSale.style.background = GetColorResultStatistick(responseStore.StartOfSaleS);
        divDotStartOfSale.style.height = "8px";
        divDotStartOfSale.style.width = "8px";
        divDotStartOfSale.style.borderRadius = "8px";
        divDotStartOfSale.style.webkitBorderRadius = "10px";
        divDotStartOfSale.style.mozBorderRadius = "10px";
        divDotStartOfSale.style.margin = "7px";
        divDotStartOfSale.style.minWidth = "8px";
        spanStartOfSale.textContent = responseStore.StartOfSale;
        spanStartOfSale.style.fontSize = "12pt";
        spanStartOfSale.style.fontFamily = "Myriad Pro";
        divParentStartOfSale.style.marginTop = "5px";
        divParentStartOfSale.appendChild(divDotStartOfSale);
        divParentStartOfSale.appendChild(spanStartOfSale);
        divRaitings.append(divParentStartOfSale);

        let spanFeedBack = document.createElement("span");
        let divDotFeedBack = document.createElement("div");
        let divParentFeedBack = document.createElement("div");
        divParentFeedBack.style.display = "flex";
        divDotFeedBack.style.background = GetColorResultStatistick(responseStore.FeedBackS);
        divDotFeedBack.style.height = "8px";
        divDotFeedBack.style.width = "8px";
        divDotFeedBack.style.borderRadius = "10px";
        divDotFeedBack.style.webkitBorderRadius = "12px";
        divDotFeedBack.style.mozBorderRadius = "12px";
        divDotFeedBack.style.margin = "7px";
        divDotFeedBack.style.minWidth = "8px";
        spanFeedBack.textContent = responseStore.FeedBack;
        spanFeedBack.style.fontSize = "12pt";
        spanFeedBack.style.fontFamily = "Myriad Pro";
        divParentFeedBack.style.marginTop = "5px";
        divParentFeedBack.appendChild(divDotFeedBack);
        divParentFeedBack.appendChild(spanFeedBack);
        divRaitings.append(divParentFeedBack);

        divRaitings.style.color = "#747474";
        divRaitings.style.padding = "10px";
        pRaitings.style.color = GetColorResultStatistick(responseStore.Seller_RatingS);
        pRaitings.style.marginLeft = "10px";
        pRaitings.textContent = responseStore.Seller_Rating + ", " + responseStore.Seller_RatingS + "%";
        sapanSl.textContent = responseStore.Seller_RatingS + "%";
        pRaitings.style.fontFamily = "Myriad Pro";
        pRaitings.style.fontSize = "22pt";
        divSaledataEl.appendChild(pRaitings);
        divSaledataEl.appendChild(divRaitings);
    }
    else {
        let spanNotData = document.createElement("span");
        sapanSl.textContent = "%";
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
        sapanPr.textContent = "$";
        spanNotData.textContent = "No data yet for this product, soon this data will appear";
        divPriceedataEl.appendChild(spanNotData);
    }
}

function ShowPrrice(elmClick) {
    let elm = elmClick.currentTarget;
    if (divPriceeEl.style.display === "none") {
        elm.style.color = "#fa3c44";
        elm.style.backgroundColor = "white";
        divPriceeEl.style.display = "block";
    }
    else {
        elm.style.color = "white";
        elm.style.backgroundColor = "#fa3c44";
        divPriceeEl.style.display = "none";
    }
}

function ShowSalle(elmClick) {
    let elm = elmClick.currentTarget;
    if (divSaleEl.style.display === "none") {
        elm.style.color = "#fa3c44";
        elm.style.backgroundColor = "white";
        divSaleEl.style.display = "block";
    }
    else {
        elm.style.color = "white";
        elm.style.backgroundColor = "#fa3c44";
        divSaleEl.style.display = "none";
    }
}

function GetColorResultStatistick(raitings) {
    let color;
    if (raitings < 60) {
        color = "#fa3c44";
    }
    else if (raitings >= 60 && 80 >= raitings) {
        color = "#D9A71F";
    }
    else if (80 < raitings) {
        color = "#0fb16e";
    }
    return color;
}