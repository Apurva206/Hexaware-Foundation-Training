document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("auth-form");
    const formTitle = document.getElementById("form-title");
    const toggleLink = document.getElementById("toggle-link");
    let isSignUp = true;

    toggleLink.addEventListener("click", () => {
        isSignUp = !isSignUp;
        formTitle.textContent = isSignUp ? "Sign Up" : "Login";
        form.querySelector("button").textContent = isSignUp ? "Sign Up" : "Login";
        toggleLink.textContent = isSignUp
            ? "Have an account? Login"
            : "No account? Register";
    });

    form.addEventListener("submit", (event) => {
        event.preventDefault();

        const username = document.getElementById("username").value.trim();
        const password = document.getElementById("password").value.trim();

        if (username === "" || password === "") {
            alert("Please fill in both fields.");
            return;
        }

        if (isSignUp) {
            if (localStorage.getItem("username") === username) {
                alert("Username already taken. Please choose a different one.");
                return;
            }

            const hashedPassword = btoa(password); 
            localStorage.setItem("username", username);
            localStorage.setItem("password", hashedPassword);
            alert("Sign Up successful! You can now login.");
        } else {
           
            const storedUsername = localStorage.getItem("username");
            const storedPassword = localStorage.getItem("password");

            if (!storedUsername || !storedPassword) {
                alert("No account found. Please sign up first.");
                return;
            }

            if (username === storedUsername && btoa(password) === storedPassword) {
                alert("Login successful!");
            } else {
                alert("Invalid username or password.");
            }
        }
    });
});
