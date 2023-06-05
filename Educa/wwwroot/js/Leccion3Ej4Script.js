const brands = [
  {
    iconName: "14/ha",
    brandName: "0",
    color: "#ff0000"
  },
  {
    iconName: "15/ja",
    brandName: "1",
    color: "#fd5c63"
  },
  {
    iconName: "14/ho",
    brandName: "2",
    color: "#333333"
  },
  {
    iconName: "15/jo",
    brandName: "3",
    color: "#a4c639"
  },
  {
    iconName: "24/ra",
    brandName: "4",
    color: "#000000"
  },
  
];
let aAudio = new Audio('/sounds/Leccion3/Pag14/ha.wav');
let eAudio = new Audio('/sounds/Leccion3/Pag15/ja.wav');
let iAudio = new Audio('/sounds/Leccion3/Pag14/ho.wav');
let oAudio = new Audio('/sounds/Leccion3/Pag15/jo.wav');
let uAudio = new Audio('/sounds/Leccion3/Pag24/ra.wav');
let mostrarPuntos = document.getElementById('puntos');
let rightAudio = new Audio('/sounds/right.wav');
let wrongAudio = new Audio('/sounds/wrong.wav');
let winAudio = new Audio('/sounds/win.wav');
let correct = 0;
let total = 0;
let audio = null;
let puntos = 5;
let link = null;
document.getElementById("success-box").style.visibility = 'hidden';
const totalDraggableItems = 5;
const totalMatchingPairs = 5; // Should be <= totalDraggableItems

const scoreSection = document.querySelector(".score");
const correctSpan = scoreSection.querySelector(".correct");
const totalSpan = scoreSection.querySelector(".total");
const playAgainBtn = scoreSection.querySelector("#play-again-btn");

const draggableItems = document.querySelector(".draggable-items");
const matchingPairs = document.querySelector(".matching-pairs");
let draggableElements;
let droppableElements;

initiateGame();

function initiateGame() {
  const randomDraggableBrands = generateRandomItemsArray(totalDraggableItems, brands);
  const randomDroppableBrands = totalMatchingPairs<totalDraggableItems ? generateRandomItemsArray(totalMatchingPairs, randomDraggableBrands) : randomDraggableBrands;
  const alphabeticallySortedRandomDroppableBrands = [...randomDroppableBrands].sort((a,b) => a.brandName.toLowerCase().localeCompare(b.brandName.toLowerCase()));
  
  // Create "draggable-items" and append to DOM
  for(let i=0; i<randomDraggableBrands.length; i++) {
    draggableItems.insertAdjacentHTML("beforeend", `
      <img class="draggable" src="/Images/Leccion/Leccion3/Pag${randomDraggableBrands[i].iconName}.png" width="48" height="48" draggable="true" style="color: ${randomDraggableBrands[i].color};" id="${randomDraggableBrands[i].iconName}"></img>
    `);
  }
  
  // Create "matching-pairs" and append to DOM
  for(let i=0; i<alphabeticallySortedRandomDroppableBrands.length; i++) {
    matchingPairs.insertAdjacentHTML("beforeend", `
      <div class="matching-pair">
        <span class="label"> <button onclick="PlaySoundB(${alphabeticallySortedRandomDroppableBrands[i].brandName})" class="sound-btn">
        &#128227;
    </button></span>
        <span class="droppable" data-brand="${alphabeticallySortedRandomDroppableBrands[i].iconName}"></span>
      </div>
    `);
  }
  
  draggableElements = document.querySelectorAll(".draggable");
  droppableElements = document.querySelectorAll(".droppable");
  
  draggableElements.forEach(elem => {
    elem.addEventListener("dragstart", dragStart);
    // elem.addEventListener("drag", drag);
    // elem.addEventListener("dragend", dragEnd);
  });
  
  droppableElements.forEach(elem => {
    elem.addEventListener("dragenter", dragEnter);
    elem.addEventListener("dragover", dragOver);
    elem.addEventListener("dragleave", dragLeave);
    elem.addEventListener("drop", drop);
  });
}

// Drag and Drop Functions

//Events fired on the drag target

function dragStart(event) {
  event.dataTransfer.setData("text", event.target.id); // or "text/plain"
}

//Events fired on the drop target

function dragEnter(event) {
  if(event.target.classList && event.target.classList.contains("droppable") && !event.target.classList.contains("dropped")) {
    event.target.classList.add("droppable-hover");
  }
}

function dragOver(event) {
  if(event.target.classList && event.target.classList.contains("droppable") && !event.target.classList.contains("dropped")) {
    event.preventDefault();
  }
}

function dragLeave(event) {
  if(event.target.classList && event.target.classList.contains("droppable") && !event.target.classList.contains("dropped")) {
    event.target.classList.remove("droppable-hover");
  }
}

function drop(event) {
  event.preventDefault();
  event.target.classList.remove("droppable-hover");
  const draggableElementBrand = event.dataTransfer.getData("text");
  const droppableElementBrand = event.target.getAttribute("data-brand");
  const isCorrectMatching = draggableElementBrand===droppableElementBrand;
  total++;
  if(isCorrectMatching) {
    
    const draggableElement = document.getElementById(draggableElementBrand);
    event.target.classList.add("dropped");
    draggableElement.classList.add("dragged");
    draggableElement.setAttribute("draggable", "false");
    event.target.innerHTML = `<img src="/Images/Leccion/Leccion3/Pag${draggableElementBrand}.png" width="48" height="48" style="color: ${draggableElement.style.color};"></img>`;
    rightAudio.play();
    correct++; 
  }
  if(!isCorrectMatching){
    wrongAudio.play();
    if(puntos == 0)
    {

    }else{
      puntos--;
    }
  }
  scoreSection.style.opacity = 0;
  setTimeout(() => {
    correctSpan.textContent = correct;
    totalSpan.textContent = total;
    scoreSection.style.opacity = 1;
  }, 200);
  if(correct===Math.min(totalMatchingPairs, totalDraggableItems)) { // Game Over!!
    
    playAgainBtn.style.display = "block";
    setTimeout(() => {
      link = `/paginas/Leccion3Ej5?puntos=${puntos}`;
      winAudio.play();
      mostrarPuntos.innerHTML = `Puntos: ${puntos}`;
      document.getElementById("success-box").style.visibility = 'visible';
    }, 200);
  }
}

// Other Event Listeners
playAgainBtn.addEventListener("click", playAgainBtnClick);
function playAgainBtnClick() {
  window.location = "/paginas/leccion1Pag8"
}

// Auxiliary functions
function generateRandomItemsArray(n, originalArray) {
  let res = [];
  let clonedArray = [...originalArray];
  if(n>clonedArray.length) n=clonedArray.length;
  for(let i=1; i<=n; i++) {
    const randomIndex = Math.floor(Math.random()*clonedArray.length);
    res.push(clonedArray[randomIndex]);
    clonedArray.splice(randomIndex, 1);
  }
  return res;
}
function PlaySoundB(num){
  switch (num) {
      
      case 0: 
        aAudio.play();
          break;
      case 1: 
        eAudio.play();
          break;
      case 2:
        iAudio.play();
        break;
      case 3:
        oAudio.play();
          break;
      case 4:
        uAudio.play();
          break;
      default:
        console.log("default");
    }
}
function Next(){
    window.location = link;
  /*/auth/login*/
}