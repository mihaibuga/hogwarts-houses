import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Layout from "./Layout";

const Create = () => {
    const [isPending, setIsPending] = useState(false);
    const [capacity, setCapacity] = useState(1);
    const navigate = useNavigate();

    const handleSubmit = (event) => {
        event.preventDefault();

        setIsPending(true);

        axios
            .post("https://localhost:44390/room", {
                capacity: capacity,
            })
            .then(() => {
                console.log("New room added");
                setIsPending(false);
                navigate("/");
            })
            .catch((error) => console.log(error));
    };

    return (
        <Layout>
            <div className="create">
                <h2>Add a New Room</h2>
                <form onSubmit={handleSubmit}>
                    <h3>New Empty room</h3>
                    <div className="form-row">
                        <label htmlFor="capacity">Capacity:</label>
                        <input
                            type="number"
                            id="quantity"
                            name="capacity"
                            min="0"
                            max="100"
                            step="1"
                            value={capacity}
                            onChange={(e) => setCapacity(e.currentTarget.value)}
                        ></input>
                    </div>

                    {!isPending && <button>Add Room</button>}
                    {isPending && <button>Adding Room</button>}
                </form>
            </div>
        </Layout>
    );
};

export default Create;
