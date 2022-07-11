import {Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from "reactstrap";
import {Link} from 'react-router-dom';
import {useState} from "react";
import './NavMenu.css';
import {useQuery} from "react-query";
import {AxiosError} from "axios";
import apiclient from "../axios.config";

type Claim = {
    type: string;
    value: string;
};

function useFetchUser() {
    return useQuery<Claim[], AxiosError>("bff/User", () =>
        apiclient.get(`/bff/User`).then((resp) => resp.data)
    );

}


export function NavMenu(){
    const [collapsed, setCollapsed] = useState(true);


    const {data, isSuccess } = useFetchUser();

    const toggleNavbar = () => setCollapsed(!collapsed);
    let logoutUrl:any;
    if(isSuccess){
        logoutUrl =
            data.find((claim) => claim.type === "bff:logout_url")?.value ??            "/bff/logout";
    }
    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">react client</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-products">Fetch products</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-locations">Fetch locations</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-all">Fetch all</NavLink>
                            </NavItem>



                        </ul>
                    </Collapse>
                    {isSuccess? <a href={logoutUrl}> Logout </a> :
                    <a href="/bff/login"> Login </a>}
                </Container>
            </Navbar>
        </header>
    );
}

