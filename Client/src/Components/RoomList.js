import React from "react";
import { Link } from "react-router-dom";

function RoomUList({ rooms, title }) {
    function isRoomAvailable(room) {
        return (room.residents.length !== 0 && room.residents.length === room.capacity) 
        ? <span className="not-available">Not Available</span> 
        : <>
            <span className="available">Available</span>
            <span> - Capacity: { room.residents.length } / { room.capacity }</span>
          </>;
    }

    return (
        <div className="room-list">
            <h2>{title}</h2>
            {rooms.length !== 0 && rooms.map((room) => (
                <div className="room-preview" key={room.id}>
                    <Link to={`/rooms/${room.id}`}>
                        <h2>Room { room.id }</h2>
                        <p>{isRoomAvailable(room)}</p> 
                    </Link>
                </div>
            ))}
            {rooms.length === 0 && 
                <>
                    <br/>
                    <h4>We're sorry, but there are no rooms of this kind yet.</h4>
                    <h4>Maybe you can try again later...</h4>
                </>
            }
        </div>
    );
}

export default RoomUList;
