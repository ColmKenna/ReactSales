import axios from "axios";
export default axios.create({
    headers: {
        "X-CSRF": 1
    }
});