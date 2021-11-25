import { useState } from "react";
import useFetch from "../useFetch";
import RoomList from "../Components/RoomList";
import Layout from "./Layout";

const Home = () => {
    const [baseLink, setBaseLink] = useState("https://localhost:44390/room");
    const { data: rooms, isLoading, error } = useFetch(baseLink);
    const [title, setTitle] = useState("All Rooms");
    const [sortBy, setSortBy] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault();
        if (sortBy === "") {
            setBaseLink("https://localhost:44390/room");
            setTitle("All Rooms");
        } else if (sortBy === "available") {
            setBaseLink("https://localhost:44390/available");
            setTitle("Available Rooms");
        } else if (sortBy === "rat-owners") {
            setBaseLink("https://localhost:44390/rat-owners");
            setTitle("Rooms with no Cats or Owls");
        }
    };

    const handleSorting = (event) => {
        event.preventDefault();
        let sortValue = event.target.value;
        setSortBy(sortValue);
    };

    return (
        <Layout>
            <div className="home">
                <form onSubmit={handleSubmit}>
                    <label>Sort By</label>
                    <select value={sortBy} onChange={handleSorting}>
                        <option value="">All</option>
                        <option value="available">Available</option>
                        <option value="rat-owners">Rat Owners</option>
                    </select>
                    <button className="submit-sort">Sort</button>
                </form>

                {error ?? <div>{error}</div>}
                {isLoading && <div>Loading...</div>}
                {rooms && <RoomList rooms={rooms} title={title} />}
            </div>
        </Layout>
    );
};

export default Home;
