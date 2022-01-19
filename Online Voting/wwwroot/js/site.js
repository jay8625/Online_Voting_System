
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#Logout1").click(function () {
    $("#logout").click();
})

$('#history').hide();
$('.historybtn').click(function () {
    $('#history').toggle(1000);
});

//$('#admin').hide();
//$('#adminbtn').click(function () {
//    $('#admin').slideToggle(500);
//});

$('.popupalert').click(function () {
    alert("Are you Sure to delete User");
});