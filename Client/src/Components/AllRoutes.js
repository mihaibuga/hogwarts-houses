import { Route, Routes } from "react-router-dom";
import Home from "../Pages/Home";
import Create from "../Pages/Create";
import RoomDetails from "../Pages/RoomDetails";
import NotFound from "../Pages/NotFound";

const AllRoutes = () => {
    return ( 
        <Routes>
            <Route exact path="/" element={<Home />} />
            <Route path="/create" element={<Create />} />
            <Route path="/rooms/:id" element={<RoomDetails />} />
            <Route path="*" element={<NotFound />} />
        </Routes>
    );
}
 
export default AllRoutes;