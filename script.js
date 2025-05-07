const canvas = document.getElementById("wheel");
const ctx = canvas.getContext("2d");
const winnerDisplay = document.getElementById("winner");
const countdownDisplay = document.getElementById("countdown");
const slices = ["Prize 1", "Prize 2", "Prize 3", "Prize 4", "Prize 5", "Prize 6", "Prize 7", "Prize 8"];
const sliceCount = slices.length;
const anglePerSlice = (2 * Math.PI) / sliceCount;
let rotation = 0;
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
        // Text
        ctx.save();
        ctx.translate(radius, radius);
        ctx.rotate(startAngle + anglePerSlice / 2);
        ctx.textAlign = "right";
        ctx.fillStyle = "#000";
        ctx.font = "16px sans-serif";
        ctx.fillText(slices[i], radius - 10, 5);
        ctx.restore();
    }
}
function spinWheel()
{
    const spinAngle = Math.random() * 5 + 5; // 5 to 10 full rotations
    const duration = 3000; // ms
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
    winnerDisplay.textContent = `🎉 Winner: ${slices[index]}!`;
}
drawWheel();
let countdown = 900; // total seconds until next spin
function updateCountdownDisplay(seconds)
{
    const hrs = Math.floor(seconds / 3600);
    const mins = Math.floor((seconds % 3600) / 60);
    const secs = seconds % 60;
    if (mins != 0)
    {
        if (hrs != 0) { countdownDisplay.textContent = `Next spin in: ${hrs}h ${mins}m ${secs}s`; }
        else { countdownDisplay.textContent = `Next spin in: ${mins}m ${secs}s`; }
    }
    else { countdownDisplay.textContent = `Next spin in: ${secs}s`; }
}
updateCountdownDisplay(countdown);
setInterval(() =>
{
    countdown--; if (countdown === 0)
    {
        spinWheel();
        countdown = 900; // reset timer after each spin
    }
    updateCountdownDisplay(countdown);
}, 1000);