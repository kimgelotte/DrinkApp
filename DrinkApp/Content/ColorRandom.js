// Define variable colors
var back = ["#22A7F0", "#8E44AD", "#AEA8D3", "#F62459", "#DB0A5B", "#D64541", "#D2527F", "#2C3E50", "#1E8BC3", "#87D37C", "#4ECDC4", "#3FC380", "#E87E04", "#F9690E", "#F9BF3B"];

$('.gradbg').each(function () {

    // First random color
    var rand1 = back[Math.floor(Math.random() * back.length)];
    // Second random color
    var rand2 = back[Math.floor(Math.random() * back.length)];

    var grad = $(this).css({ 'visibility': 'visible !important', 'display': 'block', opacity: 1 });

    // Convert Hex color to RGB
    function convertHex(hex, opacity) {
        hex = hex.replace('#', '');
        r = parseInt(hex.substring(0, 2), 16);
        g = parseInt(hex.substring(2, 4), 16);
        b = parseInt(hex.substring(4, 6), 16);

        // Add Opacity to RGB to obtain RGBA
        result = 'rgba(' + r + ',' + g + ',' + b + ',' + opacity / 100 + ')';
        return result;
    }

    // Gradient rules
    grad.css('background-color', convertHex(rand1, 40));
    grad.css("background-image", "-webkit-linear-gradient(top;  " + convertHex(rand1, 40) + " 0%," + convertHex(rand2, 40) + " 100%)");
    grad.css("background-image", "-o-linear-gradient(top; " + convertHex(rand1, 40) + " 0%," + convertHex(rand2, 40) + " 100%)");
    grad.css("background-image", "-ms-linear-gradient(top; " + convertHex(rand1, 40) + " 0%," + convertHex(rand2, 40) + " 100%)");
    grad.css("background-image", "linear-gradient(to bottom; " + convertHex(rand1, 40) + " 0%," + convertHex(rand2, 40) + " 100%)");
    grad.css("filter", "progid:DXImageTransform.Microsoft.gradient( startColorstr='" + convertHex(rand1, 40) + "'; endColorstr='" + convertHex(rand2, 40) + "';GradientType=0 )");
    grad.css("background-image", "-webkit-gradient(linear; left top; left bottom; color-stop(0%," + convertHex(rand1, 40) + "); color-stop(100%," + convertHex(rand2, 40) + "))");

});

