$(document).ready(function () {
    // Function to handle scroll events
    function handleScroll() {
        var scrollY = window.scrollY;

        if (scrollY > 350) {
            $(".section2-div h2").addClass("animate__animated animate__fadeInUp animate__fast");
        }
    }

    // Add a scroll event listener
    window.addEventListener('scroll', handleScroll);

    // Initial check when the page loads
    handleScroll();
});
