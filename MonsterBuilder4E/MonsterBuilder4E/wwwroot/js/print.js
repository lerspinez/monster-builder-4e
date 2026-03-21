function printComponent(selector) {
    const el = document.querySelector(selector);
    if (el) {
        const win = window.open('', '_blank');
        win.document.write(el.innerHTML);
        win.document.close();
        win.print();
    }
}

async function exportElementAsPng(selector, filename) {
    const element = document.querySelector(selector);
    if (!element) {
        console.error('Element not found:', selector);
        return;
    }

    try {
        // Use html2canvas to capture the element
        const canvas = await html2canvas(element, {
            backgroundColor: '#ffffff',
            scale: 2, // Higher quality
            logging: false,
            useCORS: true
        });

        // Convert canvas to blob
        canvas.toBlob(function(blob) {
            // Create a temporary URL for the blob
            const url = URL.createObjectURL(blob);

            // Create a temporary anchor element and trigger download
            const link = document.createElement('a');
            link.href = url;
            link.download = filename || 'statblock.png';
            document.body.appendChild(link);
            link.click();

            // Cleanup
            document.body.removeChild(link);
            URL.revokeObjectURL(url);
        }, 'image/png');
    } catch (error) {
        console.error('Error exporting as PNG:', error);
    }
}

function downloadFile(filename, contentType, content) {
    // Create a blob from the content
    const blob = new Blob([content], { type: contentType });

    // Create a temporary URL for the blob
    const url = URL.createObjectURL(blob);

    // Create a temporary anchor element and trigger download
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    document.body.appendChild(link);
    link.click();

    // Cleanup
    document.body.removeChild(link);
    URL.revokeObjectURL(url);
}