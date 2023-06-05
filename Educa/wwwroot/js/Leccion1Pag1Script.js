document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    var audio = document.getElementById("MusicIntro");
    audio.play();
}
function Siguiente() {
    window.location = "/paginas/leccion1Pag2"
}