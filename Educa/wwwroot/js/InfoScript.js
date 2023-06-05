let images = [
    "https://img.freepik.com/foto-gratis/3d-render-conjunto-joven-trabajando-agitando-mano_107791-17013.jpg?w=826&t=st=1683687632~exp=1683688232~hmac=922e7824e2cb2444eecb453668dbacf8a35bd3ec329c95c7f834839b875e3f49",
    "https://img.freepik.com/foto-gratis/astronauta-herramienta-lapiz-lapiz-trazado-recorte-creado-incluido-jpeg-facil-componer_460848-11506.jpg?w=826&t=st=1683688229~exp=1683688829~hmac=7f6cb6ee8b0b0033e32b6cb3a215dfdd439eb639242d2240bc2b60b50a6317cb",
    "https://img.freepik.com/fotos-premium/desarrollador-independiente-laptop-ilustracion-3d_588520-10.jpg?w=740"
];
let slide = document.getElementById("slider");
const slider = () => {
    let i = 0;
    setInterval(function () {
        i = i < images.length - 1 ? ++i : 0;
        slide.src = images[i];
    }, 2000);
};
slide.addEventListener("load", slider());