//Changes Container class to Container-fluid
document.addEventListener('DOMContentLoaded', function () {
    // Check if the .container element exists
    var containerDiv = document.querySelector('.container');
    if (containerDiv) {
        // Remove the 'container' class
        containerDiv.classList.remove('container');
        // Add the 'container-fluid' class
        containerDiv.classList.add('container-fluid');
    }
});

// Hiding Block Elements

// Write function which checks each id if entirely in viewport.
//Every scroll, log true or false to console. to test function.
//Then Change visibility.
document.addEventListener("DOMContentLoaded", function () {
    // Define the element IDs
    const elementIds = ["grid-container-1", "grid-container-2", "grid-container-3", "grid-container-4"];

    // Function to check if an element is in the viewport
    function isElementInViewport(el) {
        if (el) {
            const rect = el.getBoundingClientRect();
            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                rect.right <= (window.innerWidth || document.documentElement.clientWidth)
            );
        }
        return false;
    }

    function debounce(func, wait) {
        let timeout;
        return function () {
            const context = this;
            const args = arguments;
            clearTimeout(timeout);
            timeout = setTimeout(() => {
                func.apply(context, args);
            }, wait);
        };
    }

    // Function to log the results
    function logElementVisibility() {
        elementIds.forEach((id) => {
            const element = document.getElementById(id);
            if (element) {
                const isVisible = isElementInViewport(element);
                console.log(`${id} is in viewport: ${isVisible}`);
            }
        });
    }

    // Function to toggle elements' visibility
    function toggleElementsVisibility(elementIds) {
        elementIds.forEach((id) => {
            const element = document.getElementById(id);
            if (element) {
                const isVisible = isElementInViewport(element);
                if (isVisible) {
                    // If the element is in the viewport, make it visible
                    element.style.opacity = 1; // You can use 'block', 'inline', or 'inline-block' based on your layout
                } else {
                    // If the element is not in the viewport, hide it
                    element.style.opacity = 0;
                }
            }
        });
    }

    // Check if any of the elements with given IDs exist on the page
    const elementsExist = elementIds.some(id => !!document.getElementById(id));

    if (elementsExist) {
        // Add scroll event listener to call the debounced logElementVisibility function
        const debouncedLogElementVisibility = debounce(logElementVisibility, 100); // Adjust the debounce wait time as needed
        window.addEventListener("wheel", debouncedLogElementVisibility);
        window.addEventListener("scroll", debouncedLogElementVisibility);
        window.addEventListener("resize", debouncedLogElementVisibility);

        // Add a "resize" event listener to call the function when resizing
        window.addEventListener("resize", function () {
            toggleElementsVisibility(elementIds);
        });

        window.addEventListener("wheel", function () {
            toggleElementsVisibility(elementIds);
        });

        // Initial check when the page loads
        logElementVisibility();

        const visibilityInterval = setInterval(function () {
            toggleElementsVisibility(elementIds);
        }, 500);
    }
});

//Header HTML Editing

function addAdditionalNavItems() {
    var header = document.querySelector(".navbar");

    if (header) {
        var ul = header.querySelector("ul.navbar-nav");

        if (ul) {
            // Add "Home" link
            var newNavItem1 = document.createElement("li");
            newNavItem1.className = "nav-item";

            var newLink1 = document.createElement("a");
            newLink1.className = "nav-link text-dark";
            newLink1.href = "/Home/Index"; // Link to Home
            newLink1.innerText = "Home";

            newNavItem1.appendChild(newLink1);
            ul.appendChild(newNavItem1);

            // Add "Jobs" link
            var newNavItem2 = document.createElement("li");
            newNavItem2.className = "nav-item";

            var newLink2 = document.createElement("a");
            newLink2.className = "nav-link text-dark";
            newLink2.href = "/Home/Jobs"; // Link to the Jobs page
            newLink2.innerText = "Jobs";

            newNavItem2.appendChild(newLink2);
            ul.appendChild(newNavItem2);

            // Add "GenAISites" link
            var newNavItem1 = document.createElement("li");
            newNavItem1.className = "nav-item";

            var newLink1 = document.createElement("a");
            newLink1.className = "nav-link text-dark";
            newLink1.href = "/GenAIs/Index"; // Link to GenAISites
            newLink1.innerText = "GenAISites";

            newNavItem1.appendChild(newLink1);
            ul.appendChild(newNavItem1);

            // Add "Contact" link
            var newNavItem2 = document.createElement("li");
            newNavItem2.className = "nav-item";

            var newLink2 = document.createElement("a");
            newLink2.className = "nav-link text-dark";
            newLink2.href = "/Home/Contact"; // Link to the Contact page
            newLink2.innerText = "Contact";

            newNavItem2.appendChild(newLink2);
            ul.appendChild(newNavItem2);
        }
    }
}

var navbarBrand = document.querySelector(".navbar-brand");

// Check if the element exists
if (navbarBrand) {
    // Change the text to "AI"
    navbarBrand.innerText = "AI";
}

document.addEventListener("DOMContentLoaded", function () {
    var navbarBrand = document.querySelector(".navbar-brand");

    if (navbarBrand) {
        navbarBrand.innerText = "AI";
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var header = document.querySelector(".navbar");

    if (header) {
        var ul = header.querySelector("ul.navbar-nav");

        if (ul) {
            // Remove all li elements within the ul
            var liElements = ul.querySelectorAll("li");
            liElements.forEach(function (liElement) {
                ul.removeChild(liElement);
            });
        }
    }
    addAdditionalNavItems()
});

// Call the function to add the new navigation items

function replaceFooterContent() {
    var footer = document.querySelector("footer"); // Select the footer element

    // Create a new HTML structure for the footer content
    var newFooterContent = `
            <div class="container-footer">
                <div class="row">
                    <div class="col-md-3" id="footer-grid-container">
                        <a asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        <a asp-area="" asp-controller="Home" asp-action="Jobs">Jobs</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        <a asp-area="" asp-controller="Home" asp-action="AboutUs">About Us</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        Follow Us
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3" id="footer-grid-container">
                        <a asp-area="" asp-controller="Home" asp-action="GenAISites">GenAI Sites</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        <a asp-area="" asp-controller="Home" asp-action="Contact">Contact</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        <a href="#" id="copyright-info">Copyright Info</a>
                    </div>
                    <div class="col-md-3" id="footer-grid-container">
                        <!-- Social media icons -->
                        <a href="#" class="fa fa-google" id="social-icons"></a>
                        <a href="#" class="fa fa-youtube" id="social-icons"></a>
                        <a href="#" class="fa fa-twitter" id="social-icons"></a>
                        <a href="#" class="fa fa-facebook" id="social-icons"></a>
                        <a href="#" class="fa fa-linkedin" id="social-icons"></a>
                    </div>
                </div>
            </div>
        `;

    // Replace the footer's inner HTML with the new content
    footer.innerHTML = newFooterContent;
}

// Call the function to replace the footer content when the page loads
window.addEventListener("DOMContentLoaded", replaceFooterContent);

function addStylesheet(href) {
    var link = document.createElement("link");
    link.rel = "stylesheet";
    link.href = href;
    document.head.appendChild(link);
}

// Add your desired stylesheets
addStylesheet("https://fonts.googleapis.com/css?family=Anton");
addStylesheet("https://fonts.googleapis.com/css?family=Montserrat");
addStylesheet("https://fonts.googleapis.com/css?family=Dancing+Script");
addStylesheet("https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css");
addStylesheet("https://pyscript.net/latest/pyscript.css");

function addScript(src) {
    var script = document.createElement("script");
    script.src = src;
    document.head.appendChild(script);
}

// Add your desired scripts
addScript("https://pyscript.net/latest/pyscript.js");

function toggleDetails(divId) {
    var detailsDiv = document.getElementById(divId);
    var allDetailsDivs = document.querySelectorAll('.details-div');

    allDetailsDivs.forEach(function (div) {
        if (div.id === divId) {
            div.style.display = 'block';
        } else {
            div.style.display = 'none';
        }
    });

    console.log("Div Toggled");
}

function closeDetails(divId) {
    var detailsDiv = document.getElementById(divId);
    detailsDiv.style.display = 'none';
}

function addGenAIWebsite(genAIName) {
    var list = document.getElementById("genai-list");
    var listItem = document.createElement("li");
    listItem.textContent = genAIName;
    list.appendChild(listItem);
}
