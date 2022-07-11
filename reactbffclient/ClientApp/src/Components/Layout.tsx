import React from "react";
import {Container} from 'reactstrap';
import {NavMenu} from "./NavMenu";

type PropsWithChildren = {
    children: JSX.Element
};


function Layout(props: PropsWithChildren) {
    return (
        <div>
            <NavMenu/>
            <Container>
                {props.children}
            </Container>
        </div>
    );

}

export default Layout;