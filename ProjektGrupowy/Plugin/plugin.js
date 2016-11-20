
$( document ).ready(function() {
    //browser os and device info
    var client = new ClientJS();
    var data = {};
    data.timezone = client.getTimeZone();
    data.language = client.getLanguage();
    data.resolution = client.getCurrentResolution();
    data.mobile = client.isMobile();
    data.device = client.getDevice();
    data.os = client.getOS();
    data.browser = client.getBrowser();
    alert(JSON.stringify(data));

    //localisation info
    $.get( "http://ip-api.com/json?callback=?", function(json) {
        alert(JSON.stringify(json));
    });
});
