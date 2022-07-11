import React from "react";
import {useQuery} from "react-query";
import axios, {AxiosError} from "axios";
import apiclient from "../axios.config";

const useFetchAll = () => {
    return useQuery<string, AxiosError>("remote/AllUsers", () =>
        apiclient.get(`/remote/AllUsers`).then((resp) => resp.data)
    );
};

export function FetchAll() {
    const {data, status, isSuccess, error} = useFetchAll();

    return  isSuccess ? <div>{data} </div> : <div> {error?.response?.status} {error?.response?.statusText}</div>;

}