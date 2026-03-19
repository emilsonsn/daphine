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

window.startBackgroundAudio = (src, volume) => {
    const normalizedVolume = Math.min(Math.max(volume ?? 0.2, 0), 1);

    if (!window.__daphineBackgroundAudio) {
        const bg = new Audio(src);
        bg.loop = true;
        bg.volume = normalizedVolume;
        window.__daphineBackgroundAudio = bg;
    } else {
        const bg = window.__daphineBackgroundAudio;
        bg.src = src;
        bg.loop = true;
        bg.volume = normalizedVolume;
    }

    const bg = window.__daphineBackgroundAudio;

    const tryPlay = () => {
        bg.play().catch(() => {});
    };

    tryPlay();

    if (!window.__daphineBackgroundAudioUnlockRegistered) {
        const unlock = () => {
            tryPlay();
            if (!bg.paused) {
                document.removeEventListener("pointerdown", unlock);
                document.removeEventListener("keydown", unlock);
                document.removeEventListener("touchstart", unlock);
            }
        };

        document.addEventListener("pointerdown", unlock, { passive: true });
        document.addEventListener("keydown", unlock, { passive: true });
        document.addEventListener("touchstart", unlock, { passive: true });
        window.__daphineBackgroundAudioUnlockRegistered = true;
    }
};

window.getBackgroundAudioMuted = () => {
    return window.__daphineBackgroundAudio?.muted ?? false;
};

window.setBackgroundAudioMuted = (muted) => {
    const bg = window.__daphineBackgroundAudio;
    if (!bg) {
        return false;
    }

    bg.muted = !!muted;
    if (!bg.muted) {
        bg.play().catch(() => {});
    }

    return bg.muted;
};

window.toggleBackgroundAudioMuted = () => {
    const bg = window.__daphineBackgroundAudio;
    if (!bg) {
        return false;
    }

    bg.muted = !bg.muted;
    if (!bg.muted) {
        bg.play().catch(() => {});
    }

    return bg.muted;
};