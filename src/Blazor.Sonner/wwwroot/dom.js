function nextFrame() {
    return new Promise(requestAnimationFrame);
}

function getBoundingClientRect(element) {
    return element.getBoundingClientRect();
}

export const DOM = {
    nextFrame,
    getBoundingClientRect
}