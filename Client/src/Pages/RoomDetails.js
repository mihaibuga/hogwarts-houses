import { useParams } from "react-router";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";
import useFetch from "../useFetch";
import Layout from "./Layout";

const RoomDetails = () => {
    const { id } = useParams();
    const { data: room, isLoading, error } = useFetch(`https://localhost:44390/${id}`);
    const navigate = useNavigate();
    const [isRenovated, setIsRenovated] = useState(false);
    const promptMessage = "The room has been renovated!";
    const [capacity, setCapacity] = useState(0);
    const [currentCapacity, setCurrentCapacity] = useState(0);
    const [isPending, setIsPending] = useState(false);

    function isRoomAvailable(student) {
        return student ? (
            <span className="not-available">Not Available</span>
        ) : (
            <span className="available">Available</span>
        );
    }

    const handleDelete = () => {
        axios
            .delete(`https://localhost:44390/${id}`)
            .then(() => navigate("/"));
    };

    const handlePUT = (event) => {
        event.preventDefault();

        setIsPending(true);

        axios
            .put(`https://localhost:44390/${id}`, {
                id: room.id,
                capacity: capacity
            })
            .then(() => {
                setIsRenovated(true);
                setIsPending(false);
                setCurrentCapacity(capacity);
                setTimeout(() => {
                    setIsRenovated(false);
                }, 4000);
            })
            .catch((error) => console.log(error));
    };

    useEffect(() => {
        if (room !== null) {
            setCapacity(room.capacity);
            setCurrentCapacity(room.capacity);
        }
    }, [room]);

    return (
        <Layout>
            <div className="room-details">
                {isLoading && <div>Loading...</div>}
                {error && <div>{error}</div>}
                {isRenovated && <p className="successful-prompt">{promptMessage}</p>}
                {room && (
                    <article>
                        <h2>Room {room.id}</h2>
                        <p>
                            <b>Status:</b> {isRoomAvailable(room.student)}
                        </p>
                        <p>
                            <b>Capacity:</b> { room.residents.length } / { currentCapacity } students
                        </p><br/>
                        {room.residents.length === 0 &&
                            <h3>No Students</h3>
                        }
                        {room.residents.length !== 0 &&
                            <>
                                <h3>Students:</h3>
                                {room.residents.map((resident) => (
                                    <div>
                                        <h4>Student</h4>
                                        <p>
                                            <b>Name:</b> {resident.name}
                                        </p>
                                        <p>
                                            <b>House Type:</b> {resident.houseType}
                                        </p>
                                        <p>
                                            <b>Pet Type:</b> {resident.petType}
                                        </p>
                                    </div>
                                ))}
                            </>
                        }
                        
                        <form onSubmit={handlePUT}>
                            <br/>
                            <h3>Modify Room capacity</h3>
                            <div className="form-row">
                                <label htmlFor="capacity">Capacity: </label>
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
                            {!isPending && <button>Submit Capacity Change</button>}
                            {isPending && <button>Changing Capacity</button>}
                        </form>
                        <button onClick={handleDelete}>Delete</button>
                    </article>
                )}
            </div>
        </Layout>
    );
};

export default RoomDetails;
