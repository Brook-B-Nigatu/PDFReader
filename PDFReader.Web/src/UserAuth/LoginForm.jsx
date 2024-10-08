import { useState } from 'react';

export default function LoginForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const handleSubmit = async (event) => {
        event.preventDefault();
        console.log(username, password);
        setUsername("");
        setPassword("");
        setError("");

    };
    const handleUsername = (event) => {
        setUsername(event.target.value);
    };
    const handlePassword = (event) => {
        setPassword(event.target.value);
    };

    return (
        <>
            <form onSubmit={handleSubmit} >
                <label htmlFor="username">Username : </label>
                <input type="text" id="username" value={username} onChange={handleUsername} /><br></br>
                <label htmlFor="password">Password : </label>
                <input type="text" id="password" value={password} onChange={handlePassword} /><br></br>
                <input type="submit" value="Ok" />
            </form>
            <p>{error}</p>
        </>    
    );
}