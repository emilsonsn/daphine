window.playAudio = (src) => {
    const audio = new Audio(src);
    audio.play().catch(() => {});
};

window.playAudioAndWait = (src) => new Promise((resolve) => {
    const audio = new Audio(src);

    const finish = () => {
        resolve();
    };

    audio.addEventListener("ended", finish, { once: true });
    audio.addEventListener("error", finish, { once: true });

    audio.play().catch(finish);
});