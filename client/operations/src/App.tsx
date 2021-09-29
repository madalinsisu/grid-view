import './App.css';
import React, { useEffect, useState } from 'react';
import { DepositsComponent } from './components/Deposits';
import Dropdown, { Option } from 'react-dropdown';
import 'react-dropdown/style.css';
import { OperationTypeModel } from './shared/models/operation-type.model';
import { HttpService } from './services/http.service';
import { SelectItemConfig } from './shared/config/select-item.config';
import { Helper } from './shared/helper';
import { WithdrawalsComponent } from './components/Withdrawal';
import { TradeOrdersComponent } from './components/TradeOrder';
import { PaginatorComponent } from './components/Paginator';
import { operationsDropdownStyle, tableStyle } from './shared/constants/styles.constants';
import { emitCustomEvent } from 'react-custom-events';


function App() {
  const initialState: { options: SelectItemConfig[], selectedOption: SelectItemConfig | null } =
    { options: [], selectedOption: null };

  const [state, setState] =
    useState<{ options: SelectItemConfig[], selectedOption: SelectItemConfig | null }>(initialState);

  useEffect(() => {
    new HttpService<OperationTypeModel>("operation-types").getEntities().then(data => {
      setState({ ...state, options: data.items.map(Helper.OperationTypeToSelectItem) });
    });
  }, []);

  function onSelect(arg: Option) {
    setState({ ...state, selectedOption: { label: (arg.label as string), value: arg.value } })
    emitCustomEvent('option-changed', state);
  }

  const displayTable = () => {
    switch (state.selectedOption?.value) {

      case "1": return <DepositsComponent />;
      case "2": return <WithdrawalsComponent />;
      case "3": return <TradeOrdersComponent />;

      default: return <h3>Nothing to display</h3>
    }
  }

  return (
    <div className="App">
      <div style={operationsDropdownStyle}>
        <Dropdown options={state.options} value={state.selectedOption?.label} onChange={onSelect} placeholder="Select an option" />
      </div>
      <div style={tableStyle}>
        {displayTable()}
      </div>
    </div>
  );
}

export default App;
