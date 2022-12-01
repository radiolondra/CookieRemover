var gotoSettingsPage_DeleteCookies = async function () {
    await browser.runtime.sendMessage({ action: "gotoSettingsPage_DeleteCookies" })
        .then(response => {
            console.log(response);
        });
}

var gotoExtensionPage = async function () {
    await browser.runtime.sendMessage({ action: "gotoExtensionPage" })
        .then(response => {
            console.log(response);
        });
}