import React from "react";
import {useQuery} from "react-query";
import axios, {AxiosError} from "axios";
import apiclient from "../axios.config";

const useFetchLocations = () => {
    return useQuery<string, AxiosError>("remote/Locations", () =>
        apiclient.get(`/remote/Locations`).then((resp) => resp.data)
    );
};

export function FetchLocations() {
    const {data, status, isSuccess, error } = useFetchLocations();
    return (
        isSuccess ?
            <div>{data} </div> :
            <div> {error?.response?.status} {error?.response?.statusText}</div>);
}
