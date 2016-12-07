
    var client = new ClientJS();
    var data = {}, advert = {};

    if(client) {
        data.timezone = client.getTimeZone();
        data.language = client.getLanguage();
        data.resolution = client.getCurrentResolution();
        data.mobile = client.isMobile();
        data.device = client.getDevice();
        data.os = client.getOS();
        data.browser = client.getBrowser();
    }

    $.get( "http://ip-api.com/json?callback=", function(response) {
        if(response) {
            data.ip = response.query;
            data.country = response.country;
            data.region = response.region;
            data.city = response.city;
        }
        //send collected information about user
        $.post("http://localhost:3000/Collect",
        {
            jsonData: JSON.stringify(data),
            jsonDataProperties: {},
            userGuid: "838aa83a-b95e-11e6-a4a6-cec0c932ce01"
        });
    });


    //get advert template from server
    $.get( "http://localhost:3000/GetResponse", function(response) {
        advert = response.advert;
    });s
