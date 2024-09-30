import { useState } from 'react';

export default function SignupForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState("");
    const handleSubmit = async (event) => {
        event.preventDefault();
        console.log(username, password, confirmPassword);
        
        if (password === confirmPassword) {
            const formData = new FormData();
            formData.append("name", username);
            formData.append("password", password);

            const response = await fetch("api/user/signup", {
                method: "Post",
                body : formData
            });

            switch (response.status) {
                case 201:
                    setError("");
                    break;
                case 409:
                    setError("Username Taken!");
                    break;
                default:
                    setError("Please Try Again");
            }
            
        }
        else {
            setError("Passwords must match!!")
        }
        setUsername("");
        setPassword("");
        setConfirmPassword("");
        
        
    };
    const handleUsername = (event) => {
        setUsername(event.target.value);
    };
    const handlePassword = (event) => {
        setPassword(event.target.value);
    };
    const handleConfirmPassword = (event) => {
        setConfirmPassword(event.target.value);
    }

    return (
        <>
            <form onSubmit={handleSubmit} >
                <label htmlFor="username">Username : </label>
                <input type="text" id="username" value={username} onChange={handleUsername} /><br></br>
                <label htmlFor="password">Password : </label>
                <input type="text" id="password" value={password} onChange={handlePassword} /><br></br>
                <label htmlFor="confirmPassword">Confirm Password : </label>
                <input type="text" id="confirmPassword" value={confirmPassword} onChange={handleConfirmPassword} /><br></br>
                <input type="submit" value="Ok" />
            </form>
            <p>{error}</p>
        </>
        
    );
}