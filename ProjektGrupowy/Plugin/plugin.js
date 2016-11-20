
$( document ).ready(function() {
    $.get( "http://ip-api.com/json?callback=?", function(data) {
        alert(JSON.stringify(data));
    });
});