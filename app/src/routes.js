import Welcome from '@/components/Welcome'
import PlantManagement from '@/components/PlantManagement'

const routes = [{
        name: 'welcome',
        alias: '/',
        path: '/welcome',
        component: Welcome
    },
    {
        name: 'plantManagement',
        path: '/plantmanagement',
        component: PlantManagement
    }
];

export default routes;