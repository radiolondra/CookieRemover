// Import for the side effect of defining a global 'browser' variable
import * as _ from "/content/Blazor.BrowserExtension/lib/browser-polyfill.min.js";

browser.runtime.onInstalled.addListener(() => {
  const indexPageUrl = browser.runtime.getURL("index.html");
  browser.tabs.create({
    url: indexPageUrl
  });
});

browser.runtime.onMessage.addListener(
    function (request, sender, sendResponse) {
        console.log(sender.tab ?
            "from a content script:" + sender.tab.url :
            "from the extension");

        switch (request.action) {
            case "gotoSettingsPage_DeleteCookies":
                chrome.tabs.create({ url: 'chrome://settings/content/all' });
                break;

            case "gotoExtensionPage":
                chrome.tabs.create({ url: 'chrome://extensions' });
                break;
        }
        return true;    
    }
    
);