function nextFrame() {
    return new Promise(requestAnimationFrame);
}

function getBoundingClientRect(element) {
    return element.getBoundingClientRect();
}

function getDocumentDirection() {
    if (typeof window === undefined) return "ltr";
    if (typeof document === undefined) return "ltr";

    const dir = document.documentElement.getAttribute("dir");

    if (dir === "auto" || !dir) {
        return window.getComputedStyle(document.documentElement).direction;
    }

    return dir;
}

export const DOM = {
    nextFrame,
    getBoundingClientRect,
    getDocumentDirection
}