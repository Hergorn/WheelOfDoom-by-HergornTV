var countdown = 15;
var slices = ["Prize 1", "Prize 2", "Prize 3", "Prize 4"];
const countdownReset = countdown;
const canvas = document.getElementById("wheel");
const ctx = canvas.getContext("2d");
const winnerDisplay = document.getElementById("winner");
const countdownDisplay = document.getElementById("countdown");
const sliceCount = slices.length;
const anglePerSlice = (2 * Math.PI) / sliceCount;
let rotation = 0;
function loadSettings()
{
    
}

function drawWheel()
{
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    const radius = canvas.width / 2;
    for (let i = 0; i < sliceCount; i++)
    {
        const startAngle = anglePerSlice * i + rotation;
        const endAngle = startAngle + anglePerSlice;
        ctx.beginPath();
        ctx.moveTo(radius, radius);
        ctx.arc(radius, radius, radius, startAngle, endAngle);
        ctx.fillStyle = `hsl(${(i * 360) / sliceCount}, 80%, 60%)`;
        ctx.fill();
        ctx.stroke();
        ctx.save();
        ctx.translate(radius, radius);
        ctx.rotate(startAngle + anglePerSlice / 2);
        ctx.textAlign = "right";
        ctx.fillStyle = "#000";
        ctx.font = "16px sans-serif";
        ctx.fillText(slices[i], radius - 10, 5);
        ctx.restore();
    }
    ctx.beginPath();
    ctx.moveTo(canvas.width - 10, radius - 10);
    ctx.lineTo(canvas.width - 10, radius + 10);
    ctx.lineTo(canvas.width - 30, radius);
    ctx.closePath();
    ctx.fillStyle = "#FFFFFF";
    ctx.strokeStyle = "#000000"; 
    ctx.lineWidth = 2;
    ctx.fill();
    ctx.stroke();

}
function spinWheel()
{
    const spinAngle = Math.random() * 5 + 5; 
    const duration = 3000;
    const start = performance.now();
    const initialRotation = rotation;
    const totalRotation = spinAngle * 2 * Math.PI;

    function animate(now)
    {
        const elapsed = now - start;
        if (elapsed < duration)
        {
            const progress = elapsed / duration;
            rotation = initialRotation + totalRotation * easeOutCubic(progress);
            drawWheel();
            requestAnimationFrame(animate);
        }
        else
        {
            rotation = (initialRotation + totalRotation) % (2 * Math.PI);
            drawWheel();
            showWinner();
        }
    }
    requestAnimationFrame(animate);
}
function easeOutCubic(t){return 1 - Math.pow(1 - t, 3);}
function showWinner()
{
    const index = Math.floor((sliceCount - (rotation % (2 * Math.PI)) / anglePerSlice) % sliceCount);
    winnerDisplay.textContent = `${slices[index]}`;
}
drawWheel();
function updateCountdownDisplay(seconds)
{
    var hrs = Math.floor(seconds / 3600);
    var mins = Math.floor((seconds % 3600) / 60);
    var secs = seconds % 60;
    
    if (mins != 0)
    {
        if (hrs != 0)
        {
            if (hrs < 10) { hrs = "0" + hrs; }
            if (mins < 10) { mins = "0" + mins; }
            if (secs < 10) { secs = "0" + secs; }
            countdownDisplay.textContent = `${hrs}:${mins}:${secs}`;
        }
        else
        {
            if (mins < 10) { mins = "0" + mins; }
            if (secs < 10) { secs = "0" + secs; }
            countdownDisplay.textContent = `${mins}:${secs}`;
        }
    }
    else
    {
        if (secs < 10) { secs = "0" + secs; }
        countdownDisplay.textContent = `${secs}`; 
    }

}
updateCountdownDisplay(countdown);
setInterval(() =>
{
    countdown--; if (countdown === 0)
    {
        spinWheel();
        countdown = countdownReset;
    }
    updateCountdownDisplay(countdown);
}, 1000);