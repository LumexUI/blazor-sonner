window.copyToClipboard = async (element) => {
    if (!element) {
        throw Error(`Could not find an element.`);
    }

    const text = element.textContent || element.innerText;

    try {
        await navigator.clipboard.writeText(text)
        console.log('Text copied to clipboard');
    } catch (err) {
        console.error('Error copying text:', err);
    }
}