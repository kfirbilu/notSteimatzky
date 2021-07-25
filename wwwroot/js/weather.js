$(function () {
    $.ajax({
        url: 'https://api.openweathermap.org/data/2.5/weather',
        data: {
            id: '293397',
            units: 'metric',
            APPID: '50e5e552a74c7defcc7607a0fce0fdf6'
        },
        success: function (weather) {
            if (weather.main.temp > 25) {
                $('#weather_msg').html("It's pretty hot today! 🥵 <br>How about staying at home reading a book under the AC? ❄️");
            }
            else {
                $('#weather_msg').html("It's pretty cold today! 🥶 <br>How about staying over at our shop with a good book?");
            }
        }
    })
});