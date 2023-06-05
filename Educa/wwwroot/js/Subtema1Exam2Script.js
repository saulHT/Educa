//
// lib/lib.js
//
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';

let rightAudio = new Audio('/sounds/right.wav');
let wrongAudio = new Audio('/sounds/wrong.wav');
let winAudio = new Audio('/sounds/win.wav');
let aAudio = new Audio('/sounds/Leccion3/Pag13/gudi.wav');
let eAudio = new Audio('/sounds/Leccion3/Pag21/nia.wav');
let iAudio = new Audio('/sounds/Leccion3/Pag17/la.wav');
let oAudio = new Audio('/sounds/Leccion3/Pag8/ce.wav');
let uAudio = new Audio('/sounds/Leccion3/Pag27/vo.wav');
let startAudio = new Audio('/sounds/Subtema1/Exam2/Subtema1Exam2Intro.wav');
let mostrarPuntos = document.getElementById('puntos');
let link = null;
let puntos = 0;
let numQue = 0;

function Inicio(){
  document.getElementById("info-box").style.visibility = 'hidden';
  startAudio.play();
}
var Question = function (questionObj) {
  this.value = {
    text: "Question",
    answers: []
  };

  this.selectedAnswer = null;
  this.html = null;
  this.questionText = null;
  this.questionAnswers = null;
  this.questionFeedback = null;

  this.value = Object.assign(this.value, questionObj);

  this.onQuestionAnswered = ({ detail }) => {
    this.selectedAnswer = {
      value: detail.answer,
      html: detail.answerHtml
    };
    this.update();

    document.dispatchEvent(
      new CustomEvent("question-answered", {
        detail: {
          question: this,
          answer: detail.answer
        }
      })
    );
  };

  this.create = function () {
    this.html = document.createElement("div");
    this.html.classList.add("question");

    this.questionText = document.createElement("button");
    this.questionText.classList.add("sound-btn");
    this.questionText.innerHTML = '&#128227;'
    this.questionText.setAttribute('id',this.value.text);

    this.questionAnswers = document.createElement("div");
    this.questionAnswers.classList.add("answers");

    for (let i = 0; i < this.value.answers.length; i++) {
      const ansObj = this.value.answers[i];
      let answer = createAnswer(ansObj);

      answer.onclick = (ev) => {
        if (this.selectedAnswer !== null) {
          this.selectedAnswer.html.classList.remove("selected");
        }

        answer.classList.add("selected");

        this.html.dispatchEvent(
          new CustomEvent("question-answered", {
            detail: {
              answer: ansObj,
              answerHtml: answer
            }
          })
        );
      };

      this.questionAnswers.appendChild(answer);
    }

    this.questionFeedback = document.createElement("div");
    this.questionFeedback.classList.add("question-feedback");

    this.html.appendChild(this.questionText);
    this.html.appendChild(this.questionAnswers);
    this.html.appendChild(this.questionFeedback);

    this.html.addEventListener("question-answered", this.onQuestionAnswered);

    return this.html;
  };

  this.disable = function () {
    this.html.classList.add("disabled");
    this.html.onclick = (ev) => {
      ev.stopPropagation();
    };

    this.html.removeEventListener("question-answered", this.onQuestionAnswered);

    let answers = this.html.querySelectorAll(".answer");
    for (let i = 0; i < answers.length; i++) {
      let answer = answers[i];
      answer.onclick = null;
    }
  };

  this.remove = function () {
    let children = this.html.querySelectorAll("*");
    for (let i = 0; i < children.length; i++) {
      const child = children[i];
      this.html.removeChild(child);
    }

    this.html.removeEventListener("question-answered", this.onQuestionAnswered);

    this.html.parentNode.removeChild(this.html);
    this.html = null;
  };

  this.update = function () {
    let correctFeedback, incorrectFeedback;
    this.html = this.html || document.createElement("div");

    correctFeedback = "Correcto.";
    incorrectFeedback = "Incorrecto";

    if (this.selectedAnswer !== null) {
      if (this.selectedAnswer.value.isCorrect) {
        this.html.classList.add("correct");
        this.html.classList.remove("incorrect");
        this.questionFeedback.innerHTML = correctFeedback;
        rightAudio.play();
      } else {
        this.html.classList.add("incorrect");
        this.html.classList.remove("correct");
        this.questionFeedback.innerHTML = incorrectFeedback;
        wrongAudio.play();
      }
    }
  };

  function createAnswer(obj) {
    this.value = {
      text: "Answer",
      isCorrect: false
    };

    this.value = Object.assign(this.value, obj);

    this.html = document.createElement("button");
    this.html.classList.add("answer");

    this.html.textContent = this.value.text;

    return this.html;
  }
};

//
// main.js
//

let questionsData = [
  {
    text: 1,
    answers: [
      {
        text: "güi",
        isCorrect: true
      },
      {
        text: "qui",
        isCorrect: false
      },
      {
        text: "gi",
        isCorrect: false
      }
      ,
      {
        text: "ji",
        isCorrect: false
      }
    ]
  },
  {
    text: 2,
    answers: [
      {
        text: "Pa",
        isCorrect: false
      },
      {
        text: "Ya",
        isCorrect: false
      },
      {
        text: "Na",
        isCorrect: false
      },
      {
        text: "Ña",
        isCorrect: true
      }
    ]
  },
  {
    text: 3,
    answers: [
      {
        text: "La",
        isCorrect: true
      },
      {
        text: "Ma",
        isCorrect: false
      },
      {
        text: "Pa",
        isCorrect: false
      },
      {
        text: "Pa",
        isCorrect: false
      }
    ]
  },
  {
    text: 4,
    answers: [
      {
        text: "ke",
        isCorrect: false
      },
      {
        text: "ce",
        isCorrect: true
      },
      {
        text: "che",
        isCorrect: false
      },
      {
        text: "de",
        isCorrect: false
      }
    ]
  },
  {
    text: 5,
    answers: [
      {
        text: "po",
        isCorrect: false
      },
      {
        text: "cho",
        isCorrect: false
      },
      {
        text: "vo",
        isCorrect: true
      },
      {
        text: "do",
        isCorrect: false
      }
    ]
  },
  
];

// variables initialization
let questions = [];
let score = 0,
  answeredQuestions = 0;
let appContainer = document.getElementById("questions-container");
let scoreContainer = document.getElementById("score-container");
scoreContainer.innerHTML = `Correctas: ${score}/${questionsData.length}`;

/**
 * Shuffles array in place. ES6 version
 * @param {Array} arr items An array containing the items.
 */
function shuffle(arr) {
  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [arr[i], arr[j]] = [arr[j], arr[i]];
  }
}

shuffle(questionsData);

// creating questions
for (var i = 0; i < questionsData.length; i++) {
  let question = new Question({
    text: questionsData[i].text,
    answers: questionsData[i].answers
  });

  appContainer.appendChild(question.create());
  questions.push(question);
}

document.addEventListener("question-answered", ({ detail }) => {
  if (detail.answer.isCorrect) {
    score++;
  }

  answeredQuestions++;
  scoreContainer.innerHTML = `Correctas: ${score}/${questions.length}`;
  detail.question.disable();

  if (answeredQuestions == questions.length) {
    setTimeout(function () {
      puntos = score;
      link = `/paginas/Subtema1E2Finish?puntos=${puntos*4}`;
      winAudio.play();
      mostrarPuntos.innerHTML = `Nota: ${puntos*4}`;
      document.getElementById("error-box").style.visibility = 'visible';
    }, 100);
  }
});

console.log(questions, questionsData);
function Next(){
   window.location = link;
}
document.getElementById("1").onclick = function(){
  aAudio.play();
};
document.getElementById("2").onclick = function(){
  eAudio.play();
};
document.getElementById("3").onclick = function(){
  iAudio.play();
};
document.getElementById("4").onclick = function(){
  oAudio.play();
};
document.getElementById("5").onclick = function(){
  uAudio.play();
};
