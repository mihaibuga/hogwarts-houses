import { Link } from "react-router-dom";
import Layout from "./Layout";

const NotFound = () => {
    return ( 
        <Layout>
            <div className="not-found">
                <h2>Sorry</h2>
                <p>The page cannot be found</p>
                <Link to='/'>Back to the homepage...</Link>
            </div>
        </Layout>
     );
}
 
export default NotFound;