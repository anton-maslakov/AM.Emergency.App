$(function () {
    $('.datepicker').datepicker({ format: "dd.mm.yyyy" })
        .get(0).setAttribute("type", "text");
})