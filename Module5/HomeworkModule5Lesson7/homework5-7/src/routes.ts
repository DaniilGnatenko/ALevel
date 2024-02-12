import Create from './pages/Create/Create';
import Home from './pages/Home';
import Resources from './pages/Resources/Resources';
import Login from './pages/Login/Login';
import Registration from './pages/Registration/Registration';
import Users from './pages/Users/Users';
import { FC } from 'react';


interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'login-route',
        title: 'Login',
        path: '/Login',
        enabled: true,
        component: Login
    },
    {
        key: 'registration-route',
        title: 'Registration',
        path: '/Registration',
        enabled: true,
        component: Registration
    },
    {
        key: 'create-route',
        title: 'Create',
        path: '/Create',
        enabled: true,
        component: Create
    },
    {
        key: 'resources-route',
        title: 'Resources',
        path: '/Resources',
        enabled: true,
        component: Resources
    },
    {
        key: 'users-route',
        title: 'Users',
        path: '/Users',
        enabled: true,
        component: Users
    }
]