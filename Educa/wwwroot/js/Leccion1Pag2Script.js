document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
let a = false;
let b = false;
let c = false;
let d = false;
let e = false;
var audiocinco = document.getElementById("Musicuatro");
function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    var audio = document.getElementById("MusicPag1");
    audio.play();
}
function Cero() {
    a = true;
    var audio1 = document.getElementById("Musicero");
    audio1.play();
}
function Uno() {
    b = true;
    var audio2 = document.getElementById("Musicuno");
    audio2.play();
}
function Dos() {
    c = true;
    var audio3 = document.getElementById("Musicdos");
    audio3.play();
}
function Tres() {
    d = true;
    var audio4 = document.getElementById("Musictres");
    audio4.play();
}
function Cuatro() {
    e = true;
    audiocinco.play();
}
function Error() {
    document.getElementById("error-box").style.visibility = 'hidden';
}
function Siguiente() {
    if (a && b && c && d && e) {
        window.location = "/paginas/leccion1Pag3"
    } else {
        document.getElementById("error-box").style.visibility = 'visible';
        var audio6 = document.getElementById("MusicError");
        audio6.play();
    }
}