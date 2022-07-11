import React from "react";
import {useQuery} from "react-query";
import axios, {AxiosError} from "axios";
import apiclient from "../axios.config";










const useFetchProducts = () => {
    return useQuery<string, AxiosError>("remote/Products", () =>
        apiclient.get(`/remote/Products`).then((resp) => resp.data)
    );
};
export function FetchProducts() {
    const fetchProducts = useFetchProducts();
    const {data, status, error, isSuccess  } = fetchProducts;

    return (
        isSuccess ?
                <div>{data} </div> :
                <div> {error?.response?.status} {error?.response?.statusText}</div>);

}



