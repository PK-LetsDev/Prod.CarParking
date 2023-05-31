$(function () {
    $("#idcard,#entrytime,#exittime").on("keyup change clear paste",
        function () {
            queueNumber();
        });
});
function queueNumber() {

    const entryTime = moment($('#entrytime').val());
    const exitTime = moment($('#exittime').val());


    const count = moment.duration(exitTime.diff(entryTime));
    const hours = Math.floor(count.asHours());
    const minutes = Math.floor(count.asMinutes()) % 60;

    const durationText = hours + ' hours ' + minutes + ' minutes';

    $('#counttime').text(durationText);
    $('#parkingduration').show();

    const duration = moment(exitTime).diff(moment(entryTime));
    const durationInHours = Math.ceil(moment.duration(duration).asHours());
    const parkingCost = durationInHours * 20;
    $("#totalcost").text(parkingCost + ' Baht');

    //May be not work haha TT
}
