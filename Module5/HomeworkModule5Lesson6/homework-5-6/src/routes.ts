import Home from './pages/Home';
import Resources from './pages/Resources';
import SignUp from './pages/SignUp';
import Users from './pages/Users';

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
        key: 'signUp-route',
        title: 'SignUp',
        path: '/SignUp',
        enabled: true,
        component: SignUp
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