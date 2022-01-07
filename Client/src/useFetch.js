import axios from "axios";
import { useState, useEffect } from "react";

const useFetch = (url) => {
    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const abortController = new AbortController();

        setTimeout(() => {
            axios.get(url, { signal: abortController.signal })
                .then((response) => {
                    if (response.status !== 200) {
                        throw Error("Could not fetch the data for that resource...");
                    }
                    return response.data;
                })
                .then((data) => {
                    setIsLoading(false);
                    setError(null);
                    setData(data);
                })
                .catch((error) => {
                    if (error.name === 'AbortError') {
                        console.log('Fetch aborted.');
                    }
                    else {
                        setIsLoading(false);
                        setError(error.message);
                    }
                });
        }, 500);

        return () => abortController.abort();
    }, [url]);

    return { data, isLoading, error }
}

export default useFetch;