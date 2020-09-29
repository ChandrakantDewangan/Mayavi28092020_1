$(document).ready(function () {
    $(".btn-Submit").click(function () {
        var str = $(".text-Submit").val();
        var output = "";
        for (var i = 0; i < str.length; i++) {
            let singleChar = str.charAt(i);
            var addChar = singleChar.charCodeAt(0) + 5;
            var charData = String.fromCharCode(addChar);
            output += charData;
        }
        $(".text-Submit").val(output);
    });
});