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
}