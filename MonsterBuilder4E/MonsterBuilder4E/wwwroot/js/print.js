function printComponent(selector) {
    const el = document.querySelector(selector);
    if (el) {
        const win = window.open('', '_blank');
        win.document.write(el.innerHTML);
        win.document.close();
        win.print();
    }
}