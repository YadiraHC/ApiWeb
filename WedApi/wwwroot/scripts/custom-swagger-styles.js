document.addEventListener('DOMContentLoaded', function() {
    // Crea un elemento <link> para cargar el archivo CSS personalizado
    var link = document.createElement('link');
    link.rel = 'stylesheet';
    link.type = 'text/css';
    link.href = '../css/custom-swagger-styles.css'; // Utiliza la ruta correcta a tu archivo CSS

    // Agrega el elemento <link> al head del documento
    document.head.appendChild(link);
});
