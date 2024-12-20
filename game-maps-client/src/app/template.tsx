"use client"
import React from 'react'
import { Provider } from 'react-redux'
import { persistStore } from 'redux-persist';
import store from '../store';
import AuthLayout from './authLayout';
import MainLayout from './mainLayout';

const Template: React.FC<React.PropsWithChildren> = ({ children }) => {
    persistStore(store);
    return (
        <React.Fragment>
            <Provider store={store}>
                <AuthLayout>
                    <MainLayout>
                        {children}
                    </MainLayout>
                </AuthLayout>
            </Provider>
        </React.Fragment>
    )
}

export default Template