import Navbar from "../Components/Navbar";

const Layout = ({children}) => {
    return (
        <div className="container">
            <Navbar />
            <div className="content">
                {children}
            </div>
        </div>
    );
};

export default Layout;
