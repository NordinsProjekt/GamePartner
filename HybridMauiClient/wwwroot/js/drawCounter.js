function DrawLifeCounter(life,window) {
    var canvas = document.getElementById(window);
    var ctx = canvas.getContext("2d");
    //Start
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 200, 200);
    ctx.font = '116px serif';
    ctx.fillStyle = "black";
    ctx.textAlign = 'center';
    ctx.textBaseline = "middle";
    ctx.fillText(life, 100, 100);
}

function DrawPoisonCounter(poison, window) {
    var canvas = document.getElementById(window);
    var ctx = canvas.getContext("2d");
    //Start
    ctx.fillStyle = "black";
    ctx.fillRect(0, 0, 200, 200);
    ctx.font = '116px serif';
    ctx.fillStyle = "green";
    ctx.textAlign = 'center';
    ctx.textBaseline = "middle";
    ctx.fillText(poison, 100, 100);
}