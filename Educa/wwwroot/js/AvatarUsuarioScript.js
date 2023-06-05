//cpc-happy-halloween codepenchallenge

const params = new URLSearchParams(window.location.search);
const sliderId = 0;
const nameInput = document.getElementById("nameInput");
const authorInput = document.getElementById("authorInput");
const link = document.getElementById("link");
const name = document.getElementById("name");
const text = document.getElementById("text");
const author = document.getElementById("author");
const gift = document.getElementById("gift");
const card = document.getElementById("card");

setTimeout(function () {
	card.classList.add("active");
}, 1000);
const slides = [
	"/images/Home/Desliza.png",
	"https://cdn-icons-png.flaticon.com/512/3468/3468377.png",
	"https://cdn-icons-png.flaticon.com/512/1236/1236363.png",
	"https://cdn-icons-png.flaticon.com/512/477/477141.png",
	"https://cdn.icon-icons.com/icons2/1628/PNG/512/3792049-bat-blood-halloween-vampire_109050.png",
	"https://i.pinimg.com/originals/09/79/08/097908fc5b4a575a9f2e2c2be6e49223.png",
	"https://cdn-icons-png.flaticon.com/512/2701/2701729.png"
];

const status = params.get("status");
if (status === "sent") {
	card.classList.add("sent-off");
	console.log(params.get("name"));
	name.innerHTML = params.get("name") || "dear friend";
	author.innerHTML = params.get("author") || "Brawada";
	const sliderId = +params.get("slider_id") || 0;
	text.src = slides[sliderId];
} else {
	const slideWrapper = document.getElementById("wrapper");
	slides.forEach((slideText) => {
		const swiperSlide = document.createElement("div");
		swiperSlide.setAttribute("class", "swiper-slide");
		const slide = document.createElement("img");
		slide.setAttribute("class", "m-slide");
		slide.src = slideText;
		swiperSlide.appendChild(slide);
		slideWrapper.appendChild(swiperSlide);
	});

	const mySwiper = new Swiper(".swiper-container", {
		grabCursor: true,
		mousewheel: true,
		speed: 600,
		parallax: true,
		direction: "horizontal",

		centeredSlides: true,
		slidesPerView: "auto",
		initialSlide: sliderId,

		pagination: {
			el: ".swiper-pagination",
			dynamicBullets: true
		},
		navigation: {
			nextEl: ".swiper-button-next",
			prevEl: ".swiper-button-prev"
		},
		breakpoints: {
			1024: {
				direction: "vertical"
			}
		}
	});
	mySwiper.on("slideChange", function () {
		console.log("slide changed");
	});
	mySwiper.slideTo(0, 0);

	function stateChange() {
		const name = encodeURIComponent(nameInput.value);
		const author = encodeURIComponent(authorInput.value);
		const index = mySwiper.realIndex;
		link.href = `/auth/avatar?user=${name}&avatar_id=${index}`;
	}

	mySwiper.on("slideChange", stateChange);
	nameInput.addEventListener("input", stateChange);
	authorInput.addEventListener("input", stateChange);
}

gift.addEventListener("click", () => {
	gift.classList.add("active-monster");
});